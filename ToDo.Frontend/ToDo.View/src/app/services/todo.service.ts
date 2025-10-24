import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject  } from 'rxjs';
import { ToDoItem } from '../models/todo-item.model';

@Injectable({ providedIn: 'root' })
export class ToDoService {
  private apiUrl = 'http://localhost:5296/api/todo';

  tasksUpdated = new Subject<void>();

  constructor(private http: HttpClient) {}

  getAll(): Observable<ToDoItem[]> {
    return this.http.get<ToDoItem[]>(this.apiUrl);
  }

  add(item: Partial<ToDoItem>): Observable<ToDoItem> {
    return this.http.post<ToDoItem>(this.apiUrl, item);
  }

  getById(id: number): Observable<ToDoItem> {
    return this.http.get<ToDoItem>(`${this.apiUrl}/${id}`);
  }

    update(task: ToDoItem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${task.id}`, task);
  }
    notifyUpdate() {
    this.tasksUpdated.next();
  }

}
