import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileOutput, UploadFile } from 'src/app/_core/models/upload-file';
import { AsposeWordService } from 'src/app/_core/services/aspose-word.service';
import { FunctionUtility } from 'src/app/_core/utilities';

@Component({
  selector: 'app-form-input',
  templateUrl: './form-input.component.html',
  styleUrls: ['./form-input.component.scss']
})
export class FormInputComponent implements OnInit {
  accept: string = '.doc, .docx, .docm, '
  filename = 'Vui lòng chọn file để upload';
  media: UploadFile = <UploadFile>{
    file: null,
    fileType: 'PDF',
    password: ''
  }

  //#region Transfer 
  fileTypes: string[] = [
    'PDF', 'HTML', 'MD', 'JPEG'
  ]

  //#endregion


  fileOutput: FileOutput[] = [];

  key: string = '';
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private wordService: AsposeWordService,
    private functionUtility: FunctionUtility
  ) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.key = this.route.snapshot.paramMap.get('key');
    console.log('this key', this.key);
  }




  onSelectFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();

      // check file name extension
      const fileNameExtension = event.target.files[0].name.split('.').pop();
      const fileZise = event.target.files[0].size;

      if (!this.accept.includes(fileNameExtension.toLowerCase())) {
        this.filename = 'Choose file...';
        return;
      }

      // Video cannot be larger than 20MB
      if (fileZise > 20971520) {
        this.filename = 'File phải nhỏ hơn 20mb';
        return;
      }

      this.media.file = event.target.files[0];

      reader.readAsDataURL(event.target.files[0]); // read file as data url
      reader.onload = (e) => {
        this.filename = this.returnFileName( event.target.files[0].name);
      };
    }
  }

  uploadFile() {
    if (this.media.file != null) {
      if (this.key == "Transfer") {
        this.wordService.convertToPDF(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = result;
          }
        })
      }
      if (this.key == "Picture") {
        this.wordService.ThemHinhAnh(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = [{ ...result }];
          }
        })
      }
      if (this.key == "ExportPicture") {
        this.wordService.TrichXuatHinhAnh(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = result;
          }
        })
      }
      if (this.key == "Shap") {
        this.wordService.ChenVaThaoTacBieuDo(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = [{ ...result }];
          }
        })
      }
      if (this.key == "Security") {
        this.wordService.baoMat(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = [{ ...result }];
          }
        })
      }
      if (this.key == "BaoMatVoiCHUKISO") {
        this.wordService.BaoMatVoiCHUKISO(this.media).subscribe({
          next: result => {
            console.log('ressult', result);
            this.fileOutput = [{ ...result }];
          }
        })
      }
    }
  }

  returnFileName(fileName: string): string {
    let maxLength = 35;
    let file = fileName.split(/\.(?=[^\.]+$)/);
    let arr = file[0].split('');
    return arr.length > maxLength ? `${arr.filter((x, i) => i <= maxLength).join('')}... .${file[1]}` : fileName;
  }

  downloadFile(file: FileOutput) {
    this.wordService.downloadFile(file).subscribe({
      next: (ress: Blob) => {
        console.log('ress', ress);
        this.functionUtility.download(ress, file.fileName)
      }
    })
  }

  onChooseFileTypeTransfer(type: string) {
    this.media.fileType = type;
  }


  backToMain = () => this.router.navigate(['/']);
}
