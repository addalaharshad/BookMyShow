import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';

@Component({
  selector: 'app-add-show',
  templateUrl: './add-show.component.html',
  styleUrls: ['./add-show.component.scss']
})
export class AddShowComponent implements OnInit {

  public movieId:number=0;
  public theaterId:number=0;
  public showId:number=0;
  constructor(public movielists:MovieListsService) { }

  ngOnInit(): void {
  }

  onAdd()
  {
    this.movielists.postShow(this.movieId,this.theaterId,this.showId);
    alert("show added");
  }

}
