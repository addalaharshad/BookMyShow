import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import {HttpClient} from '@angular/common/http'
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class ViewDetailsComponent implements OnInit {
  public movieId!:number;
  public theaterId:any;
  public showId:any;
  public ticketsNo:any;
  public invalidTickets:boolean=false;
  public ticketsCount:any={};

  constructor(private route:ActivatedRoute,private router:Router, public movielistsservice:MovieListsService,private http:HttpClient) { }
  
  ngOnInit(): void {
    if(this.movielistsservice.loggedUser==null)
    {
      this.router.navigate(["/users/user-login"]);
    }
    this.movieId=+this.route.snapshot.params['id'];
    this.movielistsservice.getMovie(this.movieId);
    this.movielistsservice.getTheaters(this.movieId);
  }
  
  onTicketBook(showId:number,theaterId:number)
  {
    this.movielistsservice.getTickets(this.movieId,theaterId,showId);
     this.showId=showId;
     this.theaterId=theaterId;
  }

  onBook()
  {
    if(this.ticketsNo<=6 && this.ticketsNo>0)
    {
      this.movielistsservice.getOnBookTicketStatus(this.movieId,this.theaterId,this.showId,this.ticketsNo);
      //this.movielistsservice.getOnBookTickets(this.movieId,this.theaterId,this.showId,this.ticketsNo);
      this.invalidTickets=this.movielistsservice.errorMsg;
    }
    else{
      this.invalidTickets=true;
    }
  }
}
