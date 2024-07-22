import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoleModel } from '../models/RoleModel';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  constructor(private httpClient: HttpClient) {}

  fetchRoles(): Observable<RoleModel[]> {
    return this.httpClient.get<RoleModel[]>('http://localhost:5115/api/Role');
  }
}
