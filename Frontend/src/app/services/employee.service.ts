import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeModel } from '../models/EmployeeModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private httpClient: HttpClient) {}

  fetchEmployees(): Observable<EmployeeModel[]> {
    return this.httpClient.get<EmployeeModel[]>('http://localhost:5115/api/Employee');
  }
}
