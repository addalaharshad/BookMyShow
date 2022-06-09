import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class OffersComponent implements OnInit {
  public userobj:any=[];
  public userTheater:any=[];
  public userBookings:any;
  constructor(private route:Router,public movieListService:MovieListsService,public http:HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:7220/api/Tickets/getmyBookings/' + this.movieListService.loggedUser.id).subscribe(data => {
      console.log(data);
      this.userBookings = data;
      for (let obj in this.userBookings) {
        this.http.get('https://localhost:7220/api/Movies/GetMovie/' + this.userBookings[obj].movieId).subscribe((data:any) => {
           this.userobj.push(data);
           console.log(this.userobj);
        });
        this.http.get('https://localhost:7220/api/Theaters/GetTheaterName/theaterName/' + this.userBookings[obj].theaterId).subscribe((data:any) => {
          this.userTheater.push(data);
        })
      }
    })
  }
  
  onBack()
  {
    this.route.navigate(['/']);
  }

}
