import { Component, OnInit } from '@angular/core';
import { PostService } from '../post-page/services/post.service'
import { Post } from '../models/post'

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  posts : Post[];

  constructor(
    private postService : PostService
  ) { }

  ngOnInit() {
    this.getPosts();
  }

  getPosts(){
    this.postService.getPosts().subscribe(h => this.posts = h);
  }
}
