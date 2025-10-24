import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { ToDoService } from '../../../../services/todo.service';
import { ToDoItem } from '../../../../models/todo-item.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  tasks: ToDoItem[] = [];
  newTitle = '';
  newDescription = '';

  @Output() selected = new EventEmitter<ToDoItem>();

  constructor(private todoService: ToDoService) {}

ngOnInit(): void {
  this.loadTasks();

  this.todoService.tasksUpdated.subscribe(() => {
    this.loadTasks();
  });
}

  loadTasks() {
    this.todoService.getAll().subscribe({
      next: data => {
        this.tasks = data
          .sort((a, b) => Number(a.isCompleted) - Number(b.isCompleted) || a.id - b.id);
      }
    });
  }

  select(task: ToDoItem) {
    this.selected.emit(task);
  }

  addTask() {
    if (!this.newTitle.trim()) return;
    const newTask = { title: this.newTitle, description: this.newDescription, isCompleted: false };
    this.todoService.add(newTask).subscribe({
      next: _ => {
        this.newTitle = '';
        this.newDescription = '';
        this.loadTasks();
      }
    });
  }
}
