// import {LogManager, View, autoinject} from "aurelia-framework";
// import {RouteConfig, NavigationInstruction} from "aurelia-router";
// import {IIdUnit} from "../../interfaces/IIdUnit";
// import {IdUnitService} from "../../services/id-service/Id-service";
// import {BaseService} from "../../services/base-service";
// import hwcrypto from '../../hwcrypto/src/hwcrypto';
//
// export var log = LogManager.getLogger('Id.Index');
//
// // automatically inject dependencies declared as private constructor parameters
// // will be accessible as this.<variablename> in class
// @autoinject
// export class Index {
//
//   private Id: IIdUnit[] = [];
//
//   constructor(
//     private IdService: IdUnitService
//   ) {
//     log.debug('constructor');
//   }
//
//   // ============ View LifeCycle events ==============
//   created(owningView: View, myView: View) {
//     log.debug('created');
//   }
//
//   bind(bindingContext: Object, overrideContext: Object) {
//     log.debug('bind');
//   }
//
//   attached() {
//
//   }
//
//   detached() {
//     log.debug('detached');
//   }
//
//   unbind() {
//     log.debug('unbind');
//   }
//
//   // ============= Router Ids =============
//   canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
//     log.debug('canActivate');
//   }
//
//   activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
//     log.debug('activate');
//   }
//
//   canDeactivate() {
//     log.debug('canDeactivate');
//   }
//
//   deactivate() {
//     log.debug('deactivate');
//   }
//  
//   sign() {
//     hwcrypto.getCertificate({lang: 'en'}).then(function(certificate) {
//       // Do something with the certificate, like prepare the hash to be signed
//       // Now sign the hash
//       const hash = "413140d54372f9baf481d4c54e2d5c7bcf28fd6087000280e07976121dd54af2"
//       hwcrypto.sign(certificate, {type: 'SHA-256', hex: hash}, {lang: 'en'}).then(function(signature) {
//         var cert = signature;
//         console.log(signature);
//         // Do something with the signature
//       }, function(error) {
//         // Handle the error. `error.message` is one of the described error mnemonics
//         console.log("Signing failed: " + error.message);
//       });
//     });
//    
//
//   }
//  
// }
