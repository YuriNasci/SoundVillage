import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailArtistaComponent } from './detail-artista.component';

describe('DetailArtistaComponent', () => {
  let component: DetailArtistaComponent;
  let fixture: ComponentFixture<DetailArtistaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailArtistaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailArtistaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
