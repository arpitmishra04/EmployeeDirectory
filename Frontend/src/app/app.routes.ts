import { Routes } from '@angular/router';
import { EmployeeComponent } from './components/main/employee/employee.component';
import { RolesComponent } from './components/main/roles/roles.component';

export const routes: Routes = [
  { path: '', component: EmployeeComponent },
  {
    path: '',
    children: [
      {
        path: 'addEmployee',
        loadComponent: () =>
          import('./components/main/add-employee/add-employee.component').then(
            (c) => c.AddEmployeeComponent
          ),
      },
    ],
  },  
  { path: 'roles', component: RolesComponent },
  {
    path: 'roles',
    children: [
      {
        path: 'roleDetails',
        loadComponent: () =>
          import('./components/main/role-details/role-details.component').then(
            (c) => c.RoleDetailsComponent
          ),
      },
      {
        path: 'addRole',
        loadComponent: () =>
          import('./components/main/add-role/add-role.component').then(
            (c) => c.AddRoleComponent
          ),
      },
    ],
  },
];
