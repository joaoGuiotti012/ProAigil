import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.scss']
})
export class ModalEditarComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

}
