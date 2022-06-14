import {ElementRef, Component, OnInit ,QueryList, ViewChild, ViewChildren, OnDestroy } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { MovieListsService } from 'src/app/Services/movie-lists.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit,OnDestroy {
  @ViewChildren('tasknote') input: QueryList<ElementRef> | undefined;
  public counter:number=0;
  public seatChecked:any=[];
  public serviceSeatChecked:any=[];
  public checkedStatus:boolean[]=[];

  constructor(private activeModal: NgbActiveModal,public movieListService:MovieListsService,private http: HttpClient) { }

  ngOnInit(): void {
    console.log(this.movieListService.getMovieId,this.movieListService.getTheaterId,this.movieListService.getShowId)
   // this.movieListService.getSeatIDs(this.movieListService.getMovieId,this.movieListService.getTheaterId,this.movieListService.getShowId);
    for(let i=0;i<100;i++)
    {
      this.checkedStatus.push(false);
    }
   this.http.get('https://localhost:7220/api/Tickets/getseats/'+ this.movieListService.getMovieId + '/' + this.movieListService.getTheaterId + '/' + this.movieListService.getShowId).subscribe((data:any) => {
    //console.log(data);
    this.movieListService.seatsList=data;
   data.forEach((ele:any) =>{
      this.checkedStatus[ele]=true;
      //this.input?.get(data)?.nativeElement.isDisabled;
    })
    })

    //this.serviceSeatChecked=this.movieListService.seatsList;
    //console.log(this.serviceSeatChecked);
  }

  ngOnDestroy(): void {
  }

  // closeModal() {
  //   this.activeModal.close('Modal Closed');
  // }

  onCounter(i: number) {
    return new Array(i);
  }

  onCheck(x: any, e: any) {
    //this.seatChecked[e]=!this.seatChecked[e];
    for (let i = 0; i < 100; i++) {
      console.log(this.input?.get(i)?.nativeElement.checked);
    }
  }

  onSave()
  {
    for (let i = 0; i < 100; i++) {
      if (this.input?.get(i)?.nativeElement.checked === true && this.checkedStatus[i]===false) {
        this.seatChecked.push(i);
        this.counter = this.counter + 1;
      }
    }
    this.movieListService.seatSelected=this.seatChecked;
    if(this.movieListService.inputTicket!=this.counter)
    {
      alert("invalid checked");
    }
    this.activeModal.close('Modal Closed');

  }

}
