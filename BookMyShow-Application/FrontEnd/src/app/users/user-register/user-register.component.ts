import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ViewEncapsulation } from '@angular/core';



@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UserRegisterComponent implements OnInit {

  registrationForm!: FormGroup;

  constructor(private http:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.registrationForm=new FormGroup(
      {
        userName: new FormControl(null,Validators.required),
        email: new FormControl(null,[Validators.required,Validators.email]),
        password: new FormControl(null,[Validators.required,Validators.minLength(8)]),
        confirmPassword: new FormControl(null,[Validators.required]),
        mobile : new FormControl(null,[Validators.required,Validators.minLength(10)])
      }
    )
  }

  public userName:string=""
  public userEmail: string="";
  public userPassword:string="";
  public userMobile:string=""


  onSubmit()
  {
    console.log(this.registrationForm)
    const data=
      {
        "name":this.userName,
        "email":this.userEmail,
        "password":this.userPassword,
        "Mobile":this.userMobile
      }
     this.http.post('https://localhost:7220/api/Registers/PostRegister',data).subscribe(data =>{
      console.log(data);
      if(data!=null)
      {
        alert("Registered Sucessfully..!!");
        this.router.navigate(["/users/user-login"]);
      }
      else{
        alert("User Already Exists..");
      }
    })
  }

}
