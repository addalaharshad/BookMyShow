import { Component, OnInit } from '@angular/core';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  constructor(public movielists:MovieListsService,private router:Router) { }

  ngOnInit(): void {
  }

  onLogout()
  {
    this.movielists.loggedUser=null;
    this.router.navigate(["/users/user-login"])
  }
  
  
}
