import { Component,Input } from '@angular/core';
import { MultiselectDropdownComponent } from '../multiselect-dropdown/multiselect-dropdown.component';
import {CommonModule} from '@angular/common'
@Component({
  selector: 'app-multiselect-filter',
  standalone: true,
  imports: [MultiselectDropdownComponent,CommonModule],
  templateUrl: './multiselect-filter.component.html',
  styleUrl: './multiselect-filter.component.css'
})
export class MultiselectFilterComponent {
@Input() showStatus : boolean = true ;
locationLable = "Location"
statusLabel = "Status"
departmentLabel = "Department"
locations = [
  "New York","San Francisco","Chicago"
]
drpartments = [
  "Engineering","Marketing","Finance"
]
status = [
  "Active","Inactive"
]
displayEmployees() {
throw new Error('Method not implemented.');
}
resetFilters() {
throw new Error('Method not implemented.');
}



}
