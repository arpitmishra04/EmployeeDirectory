import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-role-details',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './role-details.component.html',
  styleUrl: './role-details.component.css',
})
export class RoleDetailsComponent {}
