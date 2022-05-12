import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor(private http:HttpClient,public movielists:MovieListsService,private router:Router) { }

  ngOnInit(): void {
  }
  public userEmail: string="";
  public userPassword:string="";

  onSubmit()
  {
    const data=
      {
        "email":this.userEmail,
        "password":this.userPassword,
      }
     this.http.post('https://localhost:7220/api/Registers/PostLogin',data).subscribe(data =>{
      console.log(data);
      if(data==null){
        alert("Invalid Credentials");
        return;
      }
      this.movielists.loggedUser=data;
      this.router.navigate(["/"]);
    })
  }
}
