import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.css']
})
export class ViewDetailsComponent implements OnInit {
  public movieId!:number;
  public movieName: string="";
  public theaters:any;
  public ticketsAvailable:any;
  public theaterId:any;
  public showId:any;

  constructor(private route:ActivatedRoute,private router:Router, private movielistsservice:MovieListsService,private http:HttpClient) { }

  ngOnInit(): void {
    if(this.movielistsservice.loggedUser==null)
    {
      this.router.navigate(["/users/user-login"]);
    }
    this.movieId=+this.route.snapshot.params['id'];
    this.http.get('https://localhost:7220/api/Movies/GetMovie/'+this.movieId).subscribe((data:any) =>{
    this.movieName=data[0].toString();
    })

    this.http.get('https://localhost:7220/api/Theaters/GetTheaters/'+this.movieId).subscribe(data =>{
      console.log(data);
      this.theaters=data;
    })
  }
  
  onNext()
  {
    this.movieId+=1;
    this.router.navigate(['details',this.movieId]);
  }

  onTicketBook(showId:number,theaterId:number)
  {
     this.http.get('https://localhost:7220/api/Tickets/'+this.movieId+'/'+theaterId+'/'+showId).subscribe((data:any) =>{
        this.ticketsAvailable=data[0];
     })
     this.showId=showId;
     this.theaterId=theaterId;
  }

  onBook()
  {
    this.http.get('https://localhost:7220/api/Tickets/'+this.movieId+'/'+this.theaterId+'/'+this.showId+'/'+1).subscribe(data => {
      alert("tickets booked ");
    })
  }
}
