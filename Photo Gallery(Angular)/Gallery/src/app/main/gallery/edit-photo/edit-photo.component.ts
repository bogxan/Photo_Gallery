import {Component, OnInit} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {PhotosService} from "../photos/photos.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Photo} from "../../../photo.interface";

@Component({
  selector: 'edit-photo',
  templateUrl: './edit-photo.component.html',
  styleUrls: ['./edit-photo.component.scss']
})
export class EditPhotoComponent implements OnInit{
  form: FormGroup;
  id: number = 0;
  creationDate: Date = new Date();
  constructor(
    private readonly photosService: PhotosService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router
  ) {
    this.form = new FormGroup({
      name: new FormControl('', [
        Validators.required
      ]),
      description: new FormControl('', [
        Validators.required
      ]),
      rating: new FormControl('', [
        Validators.required,
        Validators.min(1),
        Validators.max(5)
      ]),
      author: new FormControl('', [
        Validators.required
      ]),
      url: new FormControl('', [
        Validators.required
      ])
    });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      this.id = Number(params.id);
      let photo: Photo;
      this.photosService.getPhotoById(this.id).subscribe(ph => {
        photo = ph;
        this.creationDate = photo.creationDate;
        this.form.patchValue({
          name: photo.name,
          description: photo.description,
          rating: photo.rating,
          author: photo.author,
          url: photo.url
        });
      });
    });
  }

  onEditPhotoClick(){
    if(this.form.valid){
      const photo: Photo = this.form.value;
      photo.id = this.id;
      photo.creationDate = this.creationDate;
      this.form.reset();
      this.photosService.editPhoto(photo);
      this.router.navigate(['/photos']);
    }
  }

}
