import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss']
})
export class AddMovieComponent implements OnInit {

  public movieName:string="";
  public language:string="";
  public moviePath:string="";
  constructor(public movielists:MovieListsService) { }

  ngOnInit(): void {
  }

  onAdd()
  {
    console.log(this.movieName,this.language)
    this.movielists.postMovie(this.movieName,this.language,this.moviePath);
    alert("new movie added")
  }

}
