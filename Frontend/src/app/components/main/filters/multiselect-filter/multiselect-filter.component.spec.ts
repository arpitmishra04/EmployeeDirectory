import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultiselectFilterComponent } from './multiselect-filter.component';

describe('MultiselectFilterComponent', () => {
  let component: MultiselectFilterComponent;
  let fixture: ComponentFixture<MultiselectFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MultiselectFilterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MultiselectFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
