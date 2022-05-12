import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import {HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  Movies: any;

  public movies:any=[]

  constructor(private movielists:MovieListsService) { }

  ngOnInit(): void {

    this.movielists.getAllMovies().subscribe(data => {
        this.Movies=data;
        this.movies=data;
        console.log(data)
      })
    // this.http.get('Data/Movies.json').subscribe(data => {
    //   this.Movies=data;
    //   console.log(data)
    // })
  }

}
