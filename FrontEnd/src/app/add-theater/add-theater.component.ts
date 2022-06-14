import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';

@Component({
  selector: 'app-add-theater',
  templateUrl: './add-theater.component.html',
  styleUrls: ['./add-theater.component.scss']
})
export class AddTheaterComponent implements OnInit {

  public theaterName:string="";
  public theaterLocation:string="";
  constructor(public movielists:MovieListsService) { }

  ngOnInit(): void {
  }

  onAdd()
  {
    this.movielists.postTheater(this.theaterName,this.theaterLocation);
    alert("theater added");
  }

}
