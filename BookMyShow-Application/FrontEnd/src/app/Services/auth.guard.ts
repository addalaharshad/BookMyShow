import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MovieListsService } from 'src/app/Services/movie-lists.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  public data:any;
  public isAuthenticated!:boolean;
  constructor(
    private authService: MovieListsService,
    private router: Router) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        this.isAuthenticated=this.authService.chek;
        if (!this.isAuthenticated) {
            this.router.navigate(["users/user-login"]);
        }
        return this.isAuthenticated;
  }
  
}

