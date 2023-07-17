import { Injectable } from '@angular/core';
import Swal from 'sweetalert2'
const sweet = Swal.mixin({
  toast: true,
  position: 'bottom-end',
  showConfirmButton: false,
  timer: 3000,
  // background: '#999',
  timerProgressBar: true,
  didOpen: (toast) => {
    toast.addEventListener('mouseenter', Swal.stopTimer)
    toast.addEventListener('mouseleave', Swal.resumeTimer)
  }
})

@Injectable({
  providedIn: 'root'
})
export class SweetAlertService {

  constructor() { }

  showSuccess(message: string) {
    sweet.fire({
      icon: 'success',
      title: 'THÀNH CÔNG',
      text: message,
    })
  }

  showError(message: string) {
    sweet.fire({
      icon: 'error',
      title: 'LỖI',
      text: message,
    })
  }

  showWarning(message: string) {
    sweet.fire({
      icon: 'warning',
      title: 'CẢNH BÁO',
      text: message,
    })
  }

  showInfo(message: string) {
    sweet.fire({
      icon: 'info',
      // title: title,
      text: message,
    })
  }

  removeConfirm(message: string, title: string) {
    return Swal.fire({
      title: title,
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    })
  }

  confirm(message: string) {
    return Swal.fire({
      title: 'Are you sure?',
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Đồng ý'
    })
  }
}
