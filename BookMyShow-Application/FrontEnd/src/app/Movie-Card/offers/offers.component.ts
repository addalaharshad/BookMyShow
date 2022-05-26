import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class OffersComponent implements OnInit {

  constructor(private route:Router) { }

  ngOnInit(): void {
  }

  onBack()
  {
    this.route.navigate(['/']);
  }

}
