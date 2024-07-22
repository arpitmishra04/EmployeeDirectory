import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { EmployeeModel } from '../../../../models/EmployeeModel';

@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css',
})
export class EmployeeTableComponent {
  @Input() empList: EmployeeModel[] = [];
  ngOnInit() {
    console.log('Employee List:', this.empList);
  }
}
