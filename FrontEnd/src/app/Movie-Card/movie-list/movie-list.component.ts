import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import {HttpClient} from '@angular/common/http'
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class MovieListComponent implements OnInit {

  Movies: any;

  public movies:any=[]

  constructor(public movielists:MovieListsService) { }

  public lang:boolean=this.movielists.selectedLang;

  ngOnInit(): void {

    this.movielists.getAllMovies();
    // this.movielists.getAllMovies().subscribe(data => {
    //     this.Movies=data;
    //     this.movies=data;
    //     console.log(data)
    //   })

    // this.http.get('Data/Movies.json').subscribe(data => {
    //   this.Movies=data;
    //   console.log(data)
    // })
  }
}
