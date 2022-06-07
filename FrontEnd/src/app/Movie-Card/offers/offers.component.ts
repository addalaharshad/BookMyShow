import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class OffersComponent implements OnInit {

  constructor(private route:Router,public movieListService:MovieListsService) { }

  ngOnInit(): void {
    this.movieListService.getUserBookings();
  }

  onBack()
  {
    this.route.navigate(['/']);
  }

}
