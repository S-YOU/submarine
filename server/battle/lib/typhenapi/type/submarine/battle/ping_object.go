// This file was generated by typhen-api

package battle

import (
	"errors"
	"github.com/shiwano/submarine/server/battle/lib/typhenapi/core"
)

var _ = errors.New

// PingObject is a kind of TyphenAPI type.
type PingObject struct {
	Message string `codec:"message"`
}

// Coerce the fields.
func (t *PingObject) Coerce() error {
	return nil
}

// Bytes creates the byte array.
func (t *PingObject) Bytes(serializer typhenapi.Serializer) ([]byte, error) {
	if err := t.Coerce(); err != nil {
		return nil, err
	}

	data, err := serializer.Serialize(t)
	if err != nil {
		return nil, err
	}

	return data, nil
}
