import { Component, OnInit } from '@angular/core';
import { EmployeeTableComponent } from './employee-table/employee-table.component';
import { RouterLink } from '@angular/router';
import { FilterByLetterComponent } from '../filters/filter-by-letter/filter-by-letter.component';
import { MultiselectFilterComponent } from '../filters/multiselect-filter/multiselect-filter.component';
import { EmployeeModel } from '../../../models/EmployeeModel';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../../services/employee.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [
    FilterByLetterComponent,
    MultiselectFilterComponent,
    EmployeeTableComponent,
    RouterLink,
    CommonModule,
  ],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent implements OnInit {
  empData: EmployeeModel[] = [];
  
  constructor(private employeeService: EmployeeService) {}
  ngOnInit() {
    this.employeeService.fetchEmployees().subscribe((data: EmployeeModel[]) => {
      data.forEach((element) => {
        this.empData.push(element);
      });
    });

    //private async generateTableRows() {
    //console.log("inside generate table");
    //console.log(this.data.length);

    // if (this.empData.length == 0 || this.empData == null) {
    //   await fetch('assets/empData.json')
    //     .then((response) => {
    //       //console.log(response);
    //       return response.json();
    //     })
    //     .then((emp: EmployeeModel[]) => {
    //       //console.log("in promise");
    //       this.empData = emp;

    //       localStorage.setItem('EmployeeData', JSON.stringify(emp));
    //     });
    // }
  }
}
