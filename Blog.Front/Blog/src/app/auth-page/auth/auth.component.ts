import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import * as moment from '../../../../node_modules/moment/moment';
@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {



  constructor(
    private authService : AuthService
  ) { }

  ngOnInit(): void {
    console.log(localStorage.getItem('id_token'));
  }

  onSubmit(username : string, password : string){
    this.authService.authUser(username, password).subscribe(h => 
      {
        if(h['access_token'] != undefined)
          this.setSession(h['access_token']);
    })
  }

  private setSession(token : string) {
    const expiresAt = moment().add(3600,'second');

    localStorage.setItem('id_token', token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
}  

}
