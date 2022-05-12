import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.css']
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
