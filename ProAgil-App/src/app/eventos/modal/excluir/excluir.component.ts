import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.scss']
})
export class ModalExcluirComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

}
