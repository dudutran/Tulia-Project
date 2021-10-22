import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostDetail } from '../models/postdetail';
import { PostsService } from '../posts.service';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { User } from '../models/user';
@Component({
  selector: 'app-delete-post',
  templateUrl: './delete-post.component.html',
  styleUrls: ['./delete-post.component.css']
})
export class DeletePostComponent implements OnInit {
  post!: PostDetail;
  user!: User;

  constructor(
    private postService: PostsService,
    private route: ActivatedRoute,
    private location: Location,
    private userService: UserService
  ) { this.user = this.userService.userValue; }

  ngOnInit(): void {
    this.getPost();
  }

  getPost(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.postService.getPostById(id)
      .subscribe(post => this.post = post);
  }
  delete(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (this.user.role == "admin") {
      this.postService.deletePost(id).subscribe(() => { this.goBack() });
    }
    else (this.user.role == "user")
    {
      if (this.post.userId == this.user.id) this.postService.deletePost(id).subscribe(() => { this.goBack() });
      else alert("you can only delete your post!");
    }
  }
  goBack(): void {
    this.location.back();
  }
}
