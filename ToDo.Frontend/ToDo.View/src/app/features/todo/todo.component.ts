import { Component } from '@angular/core';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { DetailsComponent } from './components/details/details.component';
import { ToDoItem } from '../../models/todo-item.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [CommonModule, SidebarComponent, DetailsComponent],
  template: `
    <div class="layout">
      <app-sidebar (selected)="onSelected($event)"></app-sidebar>
      <app-details [task]="selectedTask"></app-details>
    </div>
  `,
  styles: [`
    .layout {
      display: flex;
      height: 100vh;
    }
  `]
})
export class ToDoComponent {
  selectedTask?: ToDoItem;

  onSelected(task: ToDoItem) {
    this.selectedTask = task;
  }
}
