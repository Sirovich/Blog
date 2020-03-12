import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = environment.apiUrl + 'token?';

  constructor(private http: HttpClient) { }

  authUser(username : string, password : string){
    return this.http.post(this.url+'username='+username+'&password='+password, null);
  }
}