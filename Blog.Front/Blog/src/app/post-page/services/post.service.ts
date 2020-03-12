import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment'
import { Observable } from 'rxjs';
import { Post } from '../../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private url = environment.apiUrl + 'api/posts/';

  constructor(private http: HttpClient) { }

  getPosts(): Observable<Array<Post>> {
    return this.http.get<Array<Post>>(this.url);
  }

  getPost(postId : number): Observable<Post> {
    return this.http.get<Post>(`${this.url}${postId}`);
  }
}