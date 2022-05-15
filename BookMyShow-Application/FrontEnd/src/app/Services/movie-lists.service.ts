import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {map} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieListsService {

  constructor(private http:HttpClient) {}
  public Movies:any=[];
  public loggedUser:any=null; 
  public selectedLang:boolean=false;
  public originalMovies:any;
  
  
    getAllMovies()
    {
        this.Movies=[];
        this.http.get('https://localhost:7220/api/Movies/GetMovies').subscribe((data:any) => {
        //this.Movies=data;
        var d:any;
        for( d of data){
          if(d.id===15)
          {
            d.imagePath="RRR1.jpg"
          }
          else if(d.id===16)
          {
            d.imagePath="DB.jpg"
          }
          else if(d.id===17)
          {
            d.imagePath="AV.jpg"
          }
          else if(d.id===18)
          {
            d.imagePath="BN.jpg"
          }
          this.Movies.push(d)
        }
        this.originalMovies=this.Movies;
        console.log(data)
      })
    }
    
    onFilter(lang:string)
    {

      this.Movies=this.originalMovies;
      if(lang=='All')
      {
        return;
      }

      this.Movies=this.Movies.filter((data:any) =>{
        return data.language === lang;
      })
    }
    
}
