import {Component, OnInit} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {PhotosService} from "../photos/photos.service";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'post-feedback',
  templateUrl: './post-feedback.component.html',
  styleUrls: ['./post-feedback.component.scss']
})
export class PostFeedbackComponent implements OnInit{
  form: FormGroup;
  id: number = 0;

  constructor(
    private readonly photosService: PhotosService,
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute
  ) {
    this.form = new FormGroup({
      'feedback': new FormControl('', [
        Validators.required
      ])
    });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.id = params.id;
    });
  }

  onAddFeedbackClick(){
    if(this.form.valid){
      const feedback: string = this.form.value.feedback;
      this.photosService.addFeedback(this.id, feedback);
      this.form.reset();
      this.router.navigate(['/photos']);
    }
  }
}
