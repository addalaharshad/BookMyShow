import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { HttpClient } from '@angular/common/http'
import { ViewEncapsulation } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-view-details',
  templateUrl: './view-details.component.html',
  styleUrls: ['./view-details.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class ViewDetailsComponent implements OnInit {

  public movieId!: number;
  public theaterId: any;
  public showId: any;
  public ticketsNo: any;
  public invalidTickets: boolean = false;
  public ticketsCount: any = {};
  public isDisabled: boolean = false;
  public isSubmit: boolean = false;
  public seatChecked: any = [];
  public counter: number = 0;

  constructor(public modalService: NgbModal,private route: ActivatedRoute, private router: Router, public movielistsservice: MovieListsService, private http: HttpClient) { }

  openModal() {
    //ModalComponent is component name where modal is declare
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.result.then((result) => {
      console.log(result);
    }).catch((error) => {
      console.log(error);
    });
    this.movielistsservice.inputTicket=this.ticketsNo;
  }

  ngOnInit(): void {
    if (this.movielistsservice.loggedUser == null) {
      this.router.navigate(["/users/user-login"]);
    }
    this.movieId = +this.route.snapshot.params['id'];
    this.movielistsservice.getMovie(this.movieId);
    this.movielistsservice.getTheaters(this.movieId);
    this.seatChecked=this.movielistsservice.seatsList;
  }
  
  onTicketBook(showId: number, theaterId: number) {
    this.movielistsservice.getTickets(this.movieId, theaterId, showId);
    this.showId = showId;
    this.theaterId = theaterId;
  }
  
  onBook() {
    if (this.ticketsNo <= 6 && this.ticketsNo > 0) {
      this.movielistsservice.getOnBookTicketStatus(this.movieId, this.theaterId, this.showId, this.ticketsNo);
      this.seatChecked=this.movielistsservice.seatSelected;
       console.log(this.seatChecked)
      this.seatChecked.forEach((seatId:any) => {
        this.movielistsservice.getSeatstatus(this.movieId,this.theaterId,this.showId,seatId);
        this.movielistsservice.postUserBookings(this.movieId,this.theaterId,this.showId,seatId);
        //this.input?.get(seatId)?.nativeElement.isDisabled;
      });
      this.invalidTickets = this.movielistsservice.errorMsg;
      this.isSubmit = true;
    }
    else {
      this.invalidTickets = true;
    }
  }
}