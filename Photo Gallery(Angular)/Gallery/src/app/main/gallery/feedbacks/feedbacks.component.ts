import {Component, OnInit} from "@angular/core";
import {PhotosService} from "../photos/photos.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Observable} from "rxjs";

@Component({
  selector: 'feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.scss']
})
export class FeedbacksComponent implements OnInit{
  feedbacks$: Observable<string[]>;
  id: number;
  constructor(
    private readonly photosService: PhotosService,
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.feedbacks$ = this.photosService.getFeedbacks(params.id);
      this.id = params.id;
    })
  }

  onRemoveFeedbackClick(feedback: string){
    this.photosService.removeFeedback(this.id, feedback);
    this.router.navigate(['/photos']);
  }
}
