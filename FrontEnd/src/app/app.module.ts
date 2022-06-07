import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import {Routes,RouterModule} from '@angular/router'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CardComponent } from './Movie-Card/card/card.component';
import { MovieListComponent } from './Movie-Card/movie-list/movie-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MovieListsService } from './Services/movie-lists.service';
import { OffersComponent } from './Movie-Card/offers/offers.component';
import { ViewDetailsComponent } from './Movie-Card/view-details/view-details.component';
import { UserLoginComponent } from './users/user-login/user-login.component';
import { UserRegisterComponent } from './users/user-register/user-register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './Services/auth.guard';
import { ModalComponent } from './Movie-Card/modal/modal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const appRoutes:Routes=[
  {path:'',component:MovieListComponent,canActivate:[AuthGuard]},
  {path:'details/:id',component:ViewDetailsComponent,canActivate:[AuthGuard]},
  {path:'offers',component:OffersComponent,canActivate:[AuthGuard]},
  {path:'users/user-login',component:UserLoginComponent},
  {path:'user/user-register',component:UserRegisterComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    CardComponent,
    MovieListComponent,
    NavBarComponent,
    OffersComponent,
    ViewDetailsComponent,
    UserLoginComponent,
    UserRegisterComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [
   MovieListsService,
   AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
