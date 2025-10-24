import { Component,ViewChild  } from '@angular/core';
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
      <app-details [task]="selectedTask" (statusChanged)="onStatusChanged()">
</app-details>
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
   @ViewChild('sidebar') sidebar?: SidebarComponent;
  selectedTask?: ToDoItem;

  onSelected(task: ToDoItem) {
    this.selectedTask = task;
  }
    onStatusChanged() {  if (this.sidebar) {
    this.sidebar.loadTasks();
  }
  }
}
