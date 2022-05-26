import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { map } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MovieListsService {

  constructor(private http: HttpClient, private router: Router) { }
  public Movies: any = [];
  public chek!: boolean;
  public loggedUser: any = null;
  public selectedLang: boolean = false;
  public originalMovies: any;
  public movieName: string = "";
  public theaters: any;
  public errorMsg:boolean=false;
  public ticketsAvailable: any;
  public ticketsCount: any = {};

  getMovie(movieId: number) {
    this.http.get('https://localhost:7220/api/Movies/GetMovie/' + movieId).subscribe((data: any) => {
      this.movieName = data[0].toString();
    })
  }
  getTheaters(movieId: number) {
    this.http.get('https://localhost:7220/api/Theaters/GetTheaters/' + movieId).subscribe(data => {
      console.log(data);
      this.theaters = data;
    })
  }

  getTickets(movieId: number, theaterId: number, showId: number) {
    this.http.get('https://localhost:7220/api/Tickets/' + movieId + '/' + theaterId + '/' + showId).subscribe((data: any) => {
      this.ticketsAvailable = data[0];
    })
  }

  getOnBookTickets(movieId: number, theaterId: number, showId: number, noOfTickets: number) {
      this.http.get('https://localhost:7220/api/Tickets/' + movieId + '/' + theaterId + '/' + showId + '/' + noOfTickets).subscribe(data => {
        alert("tickets booked ");
      })
  }

  getOnBookTicketStatus(movieId: number, theaterId: number, showId: number, noOfTickets: number)
  {
    this.http.get('https://localhost:7220/api/Tickets/'+movieId+'/'+theaterId+'/'+showId+'/'+this.loggedUser.id+'/'+noOfTickets).subscribe((data:any) =>{
      this.errorMsg=data;
      //alert(this.errorMsg)
      if(this.errorMsg==true)
      {
      this.getOnBookTickets(movieId,theaterId,showId,noOfTickets);
      }
    })
  }

  onLogin(data: any) {
    this.http.post('https://localhost:7220/api/Registers/CheckRegister', data).subscribe(data => {
      console.log(data);
      if (data == null) {
        alert("Invalid Credentials");
        this.chek = false;
      }
      this.loggedUser = data;
      this.router.navigate(["/"]);
      this.chek = true;
    })
  }

  getAllMovies() {
    this.Movies = [];
    this.http.get('https://localhost:7220/api/Movies/GetMovies').subscribe((data: any) => {
      //this.Movies=data;
      var d: any;
      for (d of data) {
        if (d.id === 15) {
          d.imagePath = "RRR1.jpg"
        }
        else if (d.id === 16) {
          d.imagePath = "DB.jpg"
        }
        else if (d.id === 17) {
          d.imagePath = "AV.jpg"
        }
        else if (d.id === 18) {
          d.imagePath = "BN.jpg"
        }
        this.Movies.push(d)
      }
      this.originalMovies = this.Movies;
      console.log(data)
    })
  }

  onFilter(lang: string) {

    this.Movies = this.originalMovies;
    if (lang == 'All') {
      return;
    }

    this.Movies = this.Movies.filter((data: any) => {
      return data.language === lang;
    })
  }

}
