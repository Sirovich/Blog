import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';
import { Comment } from '../../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private url = environment.apiUrl + 'api/comments/';

  constructor(private http: HttpClient) { }

  getComments(postId : number): Observable<Array<Comment>> {
    return this.http.get<Array<Comment>>(this.url+postId);
  }
}