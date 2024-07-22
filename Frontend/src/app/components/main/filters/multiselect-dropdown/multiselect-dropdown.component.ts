import { Component, Input } from '@angular/core';
import {CommonModule} from '@angular/common'
@Component({
  selector: 'app-multiselect-dropdown',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './multiselect-dropdown.component.html',
  styleUrl: './multiselect-dropdown.component.css'
})
export class MultiselectDropdownComponent {
  @Input() options: string[] = [];
  @Input() dropdownLabel: string = 'Select';
  selectedOptions: { [key: string]: string[] } = {};




  location : string [] = [];
  status : string [] = [];
  department : string[] = [];




  
  toggleDropdown(event: Event): void {
    (event.currentTarget as HTMLDivElement).children[1].classList.toggle("show");
  }

  updateSelectedOptions(event: Event, dropdownLabel: string) {
    const input = event.target as HTMLInputElement;
    if (!this.selectedOptions[dropdownLabel]) {
      this.selectedOptions[dropdownLabel] = [];
    }

    if (input.checked) {
      this.selectedOptions[dropdownLabel].push(input.value);
    } else {
      const index = this.selectedOptions[dropdownLabel].indexOf(input.value);
      if (index > -1) {
        this.selectedOptions[dropdownLabel].splice(index, 1);
      }
    }
    console.log(this.selectedOptions[dropdownLabel]);
  }
}
