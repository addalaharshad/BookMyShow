import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {map} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieListsService {

  constructor(private http:HttpClient) {}

  public loggedUser:any=null; 
  
    getAllMovies()
    {
      return this.http.get('https://localhost:7220/api/Movies/GetMovies')
    }
    
}
