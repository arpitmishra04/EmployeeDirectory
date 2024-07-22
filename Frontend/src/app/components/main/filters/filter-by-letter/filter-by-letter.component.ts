import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-filter-by-letter',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './filter-by-letter.component.html',
  styleUrl: './filter-by-letter.component.css',
})
export class FilterByLetterComponent {
  alphabets = Array.from({ length: 26 }, (_, i) => String.fromCharCode(65 + i));
  handleClick(letter: string) {
    console.log('Button clicked:', letter);
  }
}
