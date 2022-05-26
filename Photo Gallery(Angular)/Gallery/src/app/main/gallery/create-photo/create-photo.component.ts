import {Component} from "@angular/core";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Photo} from "../../../photo.interface";
import {Router} from "@angular/router";
import {PhotosService} from "../photos/photos.service";

@Component({
  selector: 'create-photo',
  templateUrl: './create-photo.component.html',
  styleUrls: ['./create-photo.component.scss']
})
export class CreatePhotoComponent{
  form: FormGroup;
  constructor(
    private readonly router: Router,
    private readonly photosService: PhotosService
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

  onAddNewPhotoClick(){
    if(this.form.valid){
      const photo: Photo = this.form.value;
      this.form.reset();
      this.photosService.addPhoto(photo);
      this.router.navigate(['/photos']);
    }
  }
}
