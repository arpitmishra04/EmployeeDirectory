import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-role-card',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './role-card.component.html',
  styleUrl: './role-card.component.css',
})
export class RoleCardComponent {
  @Input() cardList: any[] = [];
}
