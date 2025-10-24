import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToDoItem } from '../../../../models/todo-item.model';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './details.component.html',
  styleUrls: ['../details/details.component.css']
})
export class DetailsComponent {
  @Input() task?: ToDoItem;
}
