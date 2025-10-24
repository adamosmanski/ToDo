import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoItem } from '../../../../models/todo-item.model';
import { FormsModule } from '@angular/forms';
import { ToDoService } from '../../../../services/todo.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './details.component.html',
  styleUrls: ['../details/details.component.css']
})
export class DetailsComponent {
  @Input() task?: ToDoItem;
  @Output() statusChanged = new EventEmitter<void>();


constructor(private todoService: ToDoService) {}

  onStatusChange(isCompleted: boolean) {
    if (!this.task) return;
    this.task.isCompleted = isCompleted;const payload: ToDoItem = {
    id: this.task.id,
    title: this.task.title || '',
    description: this.task.description || '',
    isCompleted: this.task.isCompleted,
    createdAt: this.task.createdAt || new Date().toISOString()
  };

 this.todoService.update(payload).subscribe({
      next: () => {
        console.log('Status updated');
        this.todoService.notifyUpdate();
      },
      error: (err) => console.error('Update failed', err)
    });
  }
}
