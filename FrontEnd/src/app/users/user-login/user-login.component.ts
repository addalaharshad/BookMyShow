import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/core';
import * as crypto from 'crypto-js';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss'],
  encapsulation: ViewEncapsulation.None
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
        "password": crypto.SHA256(this.userPassword).toString(),
      }
    //  this.http.post('https://localhost:7220/api/Registers/CheckRegister',data).subscribe(data =>{
    //   console.log(data);
    //   if(data==null){
    //     alert("Invalid Credentials");
    //     return;
    //   }
    //   this.movielists.loggedUser=data;
    //   this.router.navigate(["/"]);
    // })
    this.movielists.onLogin(data);
  }
}
