import { Component } from '@angular/core';
import { MultiselectFilterComponent } from '../filters/multiselect-filter/multiselect-filter.component';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RoleCardComponent } from './role-card/role-card.component';
import { RoleModel } from '../../../models/RoleModel';
import { RoleService } from '../../../services/role.service';

@Component({
  selector: 'app-roles',
  standalone: true,
  imports: [
    MultiselectFilterComponent,
    CommonModule,
    RoleCardComponent,
    RouterLink,
  ],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css',
})
export class RolesComponent {
  cardData: RoleModel[] = [];

  constructor(private roleService: RoleService) {}
  ngOnInit() {
    this.roleService.fetchRoles().subscribe((data: RoleModel[]) => {
      data.forEach((element) => {
        this.cardData.push(element);
      });
    });
}
}
