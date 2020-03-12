import { Component, OnInit } from '@angular/core';
import { Post } from '../../models/post';
import { Comment } from '../../models/comment';
import { PostService } from '../services/post.service';
import { CommentService } from '../services/comment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { parseHostBindings } from '@angular/compiler';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  post : Post
  comments : Comment[];
  constructor(
    private postService : PostService,
    private commentService : CommentService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      this.getPost(p['postId']);
      this.getComments(p['postId']);}
    );
  }

  getPost(postId : number) {
    this.postService.getPost(postId).subscribe(p => this.post = p);
  }

  getComments(postId : number)
  {
    this.commentService.getComments(postId).subscribe(p => this.comments = p);
  }
}
